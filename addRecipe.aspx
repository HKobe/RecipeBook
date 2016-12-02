<%@ register TagPrefix="sp" TagName="Ingredient" Src="~/Ingredient.ascx" %>
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="addRecipe.aspx.cs" Inherits="addRecipe" %>
<%@ Reference  Control="~/Ingredient.ascx"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <h3>Please add your new recipe here</h3>
    <p><asp:Label ID="lblRecipName" runat="server" Text="Recipe Name: " Width="200"></asp:Label><asp:TextBox ID="txtRecipeName" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="recipeNameReq" runat="server" ErrorMessage="<br/> Recipe name is required" ControlToValidate="txtRecipeName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></p>
    <p><asp:Label ID="lblOwner" runat="server" Text="Recipe Owner: " Width="200"></asp:Label><asp:TextBox ID="txtOwner" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="ownerReq" runat="server" ErrorMessage="<br/> Recipe owner is required" ControlToValidate="txtOwner" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></p>
    <p><asp:Label ID="lblCtgry" runat="server" Text="Category: " Width="200"></asp:Label><asp:TextBox ID="txtCategory" runat="server"></asp:TextBox></p>
    <p><asp:Label ID="lblTime" runat="server" Text="Cooking Time: " Width="200"></asp:Label><asp:TextBox ID="txtTime" runat="server" Width="50"></asp:TextBox> mins. <asp:CompareValidator ID="timeCheck" runat="server" ErrorMessage="* Cooking time must be number!" ControlToValidate="txtTime" ForeColor="Red" Display="Dynamic" Type="double"></asp:CompareValidator></p>
    <p><asp:Label ID="lblServings" runat="server" Text="Number of Servings: " Width="200"></asp:Label><asp:TextBox ID="txtServings" runat="server"></asp:TextBox> persons
        <asp:RequiredFieldValidator ID="servingReq" runat="server" ErrorMessage="<br/> Number of serving is required" ControlToValidate="txtServings" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></p>
    <p><asp:Label ID="lblDesc" runat="server" Text="Recipe Description: " Width="200"></asp:Label><asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Columns="60" Rows="5">
        </asp:TextBox><asp:RequiredFieldValidator ID="descReq" runat="server" ErrorMessage="<br/> Recipe description is required" ControlToValidate="txtDesc" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator></p>
    <p>Listing of Ingredients: <br />
        <sp:Ingredient runat="server" id="Ingredient" />
        <sp:Ingredient runat="server" ID="Ingredient1" />
        <sp:Ingredient runat="server" ID="Ingredient2" />
        <sp:Ingredient runat="server" id="Ingredient3" />
        <sp:Ingredient runat="server" ID="Ingredient4" />
        <sp:Ingredient runat="server" ID="Ingredient5" />
        <sp:Ingredient runat="server" id="Ingredient6" />
        <sp:Ingredient runat="server" ID="Ingredient7" />
        <sp:Ingredient runat="server" ID="Ingredient8" />
        <sp:Ingredient runat="server" id="Ingredient9" />
        <sp:Ingredient runat="server" ID="Ingredient10" />
        <sp:Ingredient runat="server" ID="Ingredient11" />
        <sp:Ingredient runat="server" id="Ingredient12" />
        <sp:Ingredient runat="server" ID="Ingredient13" />
        <sp:Ingredient runat="server" ID="Ingredient14" />

    </p>
    <p><asp:Button ID="btnSubmit" runat="server" Text="Add your recipe" OnClick="btnSubmit_Click" /> <asp:Button ID="btnCancel" runat="server" Text="Clear all fields" CausesValidation="False" OnClick="btnCancel_Click" /></p>
</asp:Content>

