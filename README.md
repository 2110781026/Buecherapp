# Buecherapp
This is the incredible Bookmaster 

## Dev-Environemnt
a new database will be created and initialized when the application handels it's first request. To manually craete the DB call

```bash
dotnet ef database update
```

This will create an `sqlite` db file called `books.db` in the `data` directory and create all the necessary tables.

### Schema changes
Changing one of the models classes does not immedeatly affect the database schema. To apply the changes to the DB you have to create a migration.


```bash
dotnet ef migration add MyMigration
```

then apply the changes 

```bash
dotnet ef database update
```

## Deployment
Create a docker image like this

```bash
 docker build -t buecherapp -f .\Dockerfile.alpine-x64-slim .
```

and push it to the (public) docker registry

```bash
docker push MyDockerHandle/buecherapp
```

### Execute locally

to run the container locally call

```bash
docker run --rm -ti -v ${pwd}/data:/app/data -p 80:80 MyDockerHandle/buecherapp
```
