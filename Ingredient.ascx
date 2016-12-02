<%@ Control Language="C#" ClassName="Ingredient" %>

<script runat="server">    
public string IngNameText
    {
        get
        {
            return txtIngName.Text;
        }
        set
        {
            txtIngName.Text = value;
        }
    }

    public string IngQtyText
    {
        get
        {
            return txtIngQty.Text;
        }
        set
        {
            txtIngQty.Text = value;
        }
    }

    public string UnitText
    {
        get
        {
            return txtUnit.Text;
        }
        set
        {
            txtUnit.Text = value;
        }
    }

     void CheckIngNameNotEmpty(Object s, ServerValidateEventArgs e)
    {
        if (txtIngName.Text == "" && txtIngQty.Text != "") 
        {
            e.IsValid = false;
        }
    }
    
    void CheckIngQty(Object s, ServerValidateEventArgs e)
    {
        if (txtIngName.Text != "" && txtIngQty.Text =="")
        {
            e.IsValid = false;
        }
    }
    
</script>

<p><asp:Label ID="lblIngredientName" runat="server" Text="Name of Ingredient: "></asp:Label><asp:TextBox ID="txtIngName" runat="server"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblQuantity" runat="server" Text="Quantity: "></asp:Label><asp:TextBox ID="txtIngQty" runat="server" Width="30"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblUnit" runat="server" Text="Unit of Measure: "></asp:Label><asp:TextBox ID="txtUnit" runat="server" Width="100"></asp:TextBox>
    <asp:CustomValidator ID="IngNameReq" runat="server" OnServerValidate="CheckIngNameNotEmpty" ErrorMessage="* Ingredient name is required!" ControlToValidate="txtIngName" ForeColor="Red" Display="Dynamic" ValidateEmptyText="True"></asp:CustomValidator>
    <asp:CustomValidator ID="QtyReq" runat="server" OnServerValidate="CheckIngQty" ErrorMessage="* Quantity of ingredient is required!" ControlToValidate="txtIngQty" ForeColor="Red" Display="Dynamic" ValidateEmptyText="True"></asp:CustomValidator>
    <asp:CompareValidator ID="QtyCheck" runat="server" ErrorMessage="* Quantity must be number!" ControlToValidate="txtIngQty" ForeColor="Red" Display="Dynamic" Type="Double"></asp:CompareValidator>
    
</p>