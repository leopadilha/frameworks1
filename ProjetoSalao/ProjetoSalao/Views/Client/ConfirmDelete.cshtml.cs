@model Client
@{
     ViewData["Title"] = "Deletar Cliente";
}

< div class= "text-center" >
    < h2 > Deseja realmente deletar o Cliente @Model.Name</h2>
</div>

<a role="button" asp-action="index" asp-controller="Client" class= "btn btn-primary" > Cancelar exclus�o </ a >
< a role = "button" asp - action = "Remove" asp - controller = "Client" asp - route - id = "@Model.Id" class= "btn btn-primary" > Deletar </ a >