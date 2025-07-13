@ModelType IEnumerable(Of capaAdministracion.usuarios)

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.idUsuario)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Nombre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Email)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Movil)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Rol)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Clave)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Estado)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.idUsuario)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Nombre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Email)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Movil)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Rol)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Clave)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Estado)
        </td>
        <td>
            @*@Html.ActionLink("Edit", "Edit", New With {.id = item.PrimaryKey}) |
            @Html.ActionLink("Details", "Details", New With {.id = item.PrimaryKey}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.PrimaryKey})*@
        </td>
    </tr>
Next

</table>
