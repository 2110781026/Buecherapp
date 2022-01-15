$BaseUrl = "https://localhost:5001/"
$end = $false 
while ($end -eq $false) {
    

Write-Host "Hello there, `n this is the magnificent Bookmaster 3000! `n What do you want to do ? `n Get a [L]ist of all books `n [A]dd a book `n [C]hange an existing book `n retrive a [S]pecific Book `n do you want to [D]elete a book `n or do you want to [E]xit the application"
$userInput = Read-Host

if ($userInput -eq "E")
{
    $end = $true
}

if ($userInput -eq "L")
{
    (Invoke-WebRequest -Uri ($Uri +"book") -SkipCertificateCheck).content | ConvertFrom-Json
}

if ($userInput -eq "A")
{
    $title = read-host "title:"
    $author = read-host "author:"
    $genre = read-host "genre:"
    $rating = read-host "rating:"
    if (($isread = read-host "boolean isread:") -eq ""){$isread = "false"}
    else {
        $isread = "true"
    }
    if (($isowned = read-host "boolean isread:") -eq ""){$isowned = "false"}
    else {
        $isowned = "true"
    }
    $currentlyLeantto = read-host "currently lent to:"
    $isbn = read-host "isbn:"
    
    

    $Body = @{}
    if( $title -ne "") { $Body.add("title", $title) }
    if( $author -ne "") { $Body.add("author", $author) }
    if( $genre -ne "") { $Body.add("genre", $genre) }
    if( $rating -ne "" ) { $Body.add("rating", $rating) }
    $Body.add("isread",([System.Convert]::ToBoolean($isread)))
    $Body.add("owned",([System.Convert]::ToBoolean($isowned)))
    if( $currentlyLeantto -ne "" ) { $Body.add("currentlyLeantto", $currentlyLeantto) }
    if( $isbn -ne "") { $Body.add("isbn", $isbn) }
    

    $JsonBody = $Body.where({ $_ -ne ""}) | ConvertTo-Json

    $JsonBody

    $Params = @{
        Method = "Post"
        Uri = $BaseUrl + "Book"
        Body = $JsonBody
        ContentType = "application/json"
    }

    Invoke-RestMethod @Params -SkipCertificateCheck
}

if ($userInput -eq "S")
{
    $id = read-host "provide the id for the Book you want to retrieve:"



    (Invoke-WebRequest -Uri ($Uri +"book/" + $id) -SkipCertificateCheck).content | ConvertFrom-Json

}

if ($userInput -eq "D")
{
    $id = read-host "provide the id for the Book you want to delete:"
    
    Invoke-WebRequest -Uri ($Uri +"book/" + $id) -SkipCertificateCheck -Method Delete
}


if ($userInput -eq "C")
{
    $id = read-host "provide the id for the Book you want to change:"

        $title = read-host "title:"
        $author = read-host "author:"
        $genre = read-host "genre:"
        $rating = read-host "rating:"
        $isread = read-host "boolean isread:"
        $isowned = read-host "boolean isread:"
        $currentlyLeantto = read-host "currently lent to:"
        $isbn = read-host "isbn:"
        
        
    
        $Body = @{}
        if( $title -ne "") { $Body.add("title", $title) }
        if( $author -ne "") { $Body.add("author", $author) }
        if( $genre -ne "") { $Body.add("genre", $genre) }
        if( $rating -ne "" ) { $Body.add("rating", $rating) }
        if ($isread -eq "true" -or $isread -eq "false")
        {   
        $Body.add("isread",([System.Convert]::ToBoolean($isread)))
        }
        if ($isread -eq "true" -or $isread -eq "false")
        {
        $Body.add("owned",([System.Convert]::ToBoolean($isowned)))
        }
        if( $currentlyLeantto -ne "" ) { $Body.add("currentlyLeantto", $currentlyLeantto) }
        if( $isbn -ne "") { $Body.add("isbn", $isbn) }
        
    
        $JsonBody = $Body.where({ $_ -ne ""}) | ConvertTo-Json
    
        $JsonBody
    
        $Params = @{
            Method = "Put"
            Uri = $BaseUrl + "Book/" + $id
            Body = $JsonBody
            ContentType = "application/json"
        }
    


    Invoke-RestMethod @Params -SkipCertificateCheck
}

}
Write-Host "end of App" 