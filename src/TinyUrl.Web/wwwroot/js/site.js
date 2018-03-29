// Write your Javascript code.
function copyText() 
{
    var urlElement = document.getElementById("url")
    urlElement.select();
    document.execCommand("Copy");
}
