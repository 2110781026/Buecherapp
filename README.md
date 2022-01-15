# Buecherapp
This is the incredible Bookmaster 

## Dev-Environment
A new database will be created and initialized when the application handels it's first request. To manually craete the DB call

```bash
dotnet ef database update
```

This will create an `sqlite` db file called `books.db` in the `data` directory and create all the necessary tables.

### Schema changes
Changing one of the models classes does not immedeatly affect the database schema. To apply the changes to the DB you have to create a migration.


```bash
dotnet ef migration add MyMigration
```

Then apply the changes.

```bash
dotnet ef database update
```

## Deployment
Create a docker image like this

```bash
 docker build -t buecherapp -f .\Dockerfile.alpine-x64-slim .
```

And push it to the (public) docker registry.

```bash
docker push MyDockerHandle/buecherapp
```

### Execute locally

to run the container locally call

```bash
docker run --rm -ti -v ${pwd}/data:/app/data -p 80:80 MyDockerHandle/buecherapp
```

### Run in Azure
Create a service plan.

```bash
az appservice plan create -g buecherAppGrp -n DkrPlan --is-linux
```

Create the webapp.

```bash
az webapp create --name buecherapp -g bucherAppGrp --plan DkrPlan -i MyDockerHandle/Buecherapp
```

Create a storage account and fileshare.

```bash
az storage account create -g buecherAppGrp --name buecherappstorage --location westeurope --sku Standard_LRS
az storage container create --name buechershare --account-name buecherappstorage
az storage account keys list --resource-group buecherAppGrp --account-name buecherappstorage | jq '.[0] | {key: .value}'
```

Having all the part you now can mount the storage.

```bash
az webapp config storage-account add -g buecherAppGrp --name buecherapp \
   --custom-id data \
   --storage-type AzureBlob \
   --account-name buecherappstorage \
   --share-name buechershare \
   --access-key "..." \  
   --mount-path /app/data
```
