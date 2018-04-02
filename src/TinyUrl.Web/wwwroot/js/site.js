// Write your Javascript code.
function copyText() 
{
    let urlElement = document.getElementById("url")
    urlElement.select();
    document.execCommand("Copy");
}
