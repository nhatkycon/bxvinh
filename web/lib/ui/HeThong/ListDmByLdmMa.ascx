<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ListDmByLdmMa.ascx.cs" Inherits="lib_ui_HeThong_ListDmByLdmMa" %>
<select name="<%=CssName %>" class="<%=CssName %>" >
    <% foreach (var Item in List)
       {%>
        <option value="<%=Item.ID %>">
            <%=Item.Ten %>
        </option>
    <%   } %>
</select>