$BaseUrl = "https://localhost:5001/"
Write-Host "Hello there, `n this is the magnificent Bookmaster 3000! `n What do you want to do ? `n Get a [L]ist of all books `n [A]dd a book `n [C]hange an existing book `n retrive a [S]pecific Book `n do you want to [D]elete a book `n or do you want to [E]xit the application"
$userInput = Read-Host

if ($userInput -eq "E")
{
    Exit
}

if ($userInput -eq "L")
{
    Invoke-WebRequest -Uri "$BaseUrl/Book" -Method get 
}

if ($userInput -eq "A")
{
    $title = read-host "title:"
    $author = read-host "author:"
    $genre = read-host "genre:"
    $rating = read-host "rating:"
    $isread = read-host "boolean isread:"
    $isowned = read-host "boolean isowned:"
    $currentlyLeantto = read-host "currently lent to:"
    $isbn = read-host "isbn:"
    Invoke-WebRequest -Uri "$BaseUrl/Book" -Method post - "{\"id\":0,\"title\":\"$title\",\"author\":\"$author\",\"genre\":\"$genre\",\"rating\":$rating\"isRead\":$isread,\"owned\":$isowned,\"currentlyLentTo\":\"$currentlyLeantto",\"isbn\":\"$isbn"}"
}
if ($userInput -eq "C")
{
    $id = read-host "provide the id for the Book you want to change:"


    Invoke-WebRequest -Uri "$BaseUrl/Book" -Method update $id
}

Write-Host "end of App" 