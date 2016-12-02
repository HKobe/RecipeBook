<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="recipes.aspx.cs" Inherits="recipes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3>List of Recipes</h3>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" style="margin-right: 4px" Width="960px" HorizontalAlign="Center">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="recipeID" HeaderText="Recipe #" />
            <asp:BoundField DataField="recipeName" HeaderText="Recipes" />
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM &quot;RECIPES&quot; WHERE &quot;RECIPEID&quot; = ? AND &quot;RECIPENAME&quot; = ? AND &quot;RECIPEOWNER&quot; = ? AND ((&quot;CATEGORY&quot; = ?) OR (&quot;CATEGORY&quot; IS NULL AND ? IS NULL)) AND ((&quot;COOKINGTIME&quot; = ?) OR (&quot;COOKINGTIME&quot; IS NULL AND ? IS NULL)) AND &quot;SERVING#&quot; = ? AND &quot;DESCRIPTION&quot; = ?" InsertCommand="INSERT INTO &quot;RECIPES&quot; (&quot;RECIPEID&quot;, &quot;RECIPENAME&quot;, &quot;RECIPEOWNER&quot;, &quot;CATEGORY&quot;, &quot;COOKINGTIME&quot;, &quot;SERVING#&quot;, &quot;DESCRIPTION&quot;) VALUES (?, ?, ?, ?, ?, ?, ?)" OldValuesParameterFormatString="original_{0}" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;RECIPEID&quot;, &quot;RECIPENAME&quot;, &quot;RECIPEOWNER&quot;, &quot;CATEGORY&quot;, &quot;COOKINGTIME&quot;, &quot;SERVING#&quot; AS column1, &quot;DESCRIPTION&quot; FROM &quot;RECIPES&quot;" UpdateCommand="UPDATE &quot;RECIPES&quot; SET &quot;RECIPENAME&quot; = ?, &quot;RECIPEOWNER&quot; = ?, &quot;CATEGORY&quot; = ?, &quot;COOKINGTIME&quot; = ?, &quot;SERVING#&quot; = ?, &quot;DESCRIPTION&quot; = ? WHERE &quot;RECIPEID&quot; = ? AND &quot;RECIPENAME&quot; = ? AND &quot;RECIPEOWNER&quot; = ? AND ((&quot;CATEGORY&quot; = ?) OR (&quot;CATEGORY&quot; IS NULL AND ? IS NULL)) AND ((&quot;COOKINGTIME&quot; = ?) OR (&quot;COOKINGTIME&quot; IS NULL AND ? IS NULL)) AND &quot;SERVING#&quot; = ? AND &quot;DESCRIPTION&quot; = ?">
        <DeleteParameters>
            <asp:Parameter Name="original_RECIPEID" Type="Decimal" />
            <asp:Parameter Name="original_RECIPENAME" Type="String" />
            <asp:Parameter Name="original_RECIPEOWNER" Type="String" />
            <asp:Parameter Name="original_CATEGORY" Type="String" />
            <asp:Parameter Name="original_CATEGORY" Type="String" />
            <asp:Parameter Name="original_COOKINGTIME" Type="Decimal" />
            <asp:Parameter Name="original_COOKINGTIME" Type="Decimal" />
            <asp:Parameter Name="original_column1" Type="Decimal" />
            <asp:Parameter Name="original_DESCRIPTION" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="RECIPEID" Type="Decimal" />
            <asp:Parameter Name="RECIPENAME" Type="String" />
            <asp:Parameter Name="RECIPEOWNER" Type="String" />
            <asp:Parameter Name="CATEGORY" Type="String" />
            <asp:Parameter Name="COOKINGTIME" Type="Decimal" />
            <asp:Parameter Name="column1" Type="Decimal" />
            <asp:Parameter Name="DESCRIPTION" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="RECIPENAME" Type="String" />
            <asp:Parameter Name="RECIPEOWNER" Type="String" />
            <asp:Parameter Name="CATEGORY" Type="String" />
            <asp:Parameter Name="COOKINGTIME" Type="Decimal" />
            <asp:Parameter Name="column1" Type="Decimal" />
            <asp:Parameter Name="DESCRIPTION" Type="String" />
            <asp:Parameter Name="original_RECIPEID" Type="Decimal" />
            <asp:Parameter Name="original_RECIPENAME" Type="String" />
            <asp:Parameter Name="original_RECIPEOWNER" Type="String" />
            <asp:Parameter Name="original_CATEGORY" Type="String" />
            <asp:Parameter Name="original_CATEGORY" Type="String" />
            <asp:Parameter Name="original_COOKINGTIME" Type="Decimal" />
            <asp:Parameter Name="original_COOKINGTIME" Type="Decimal" />
            <asp:Parameter Name="original_column1" Type="Decimal" />
            <asp:Parameter Name="original_DESCRIPTION" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>

