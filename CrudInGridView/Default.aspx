﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CrudInGridView.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:GridView ID="gvUchet" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="InfoID"
                ShowHeaderWhenEmpty="true"

                OnRowCommand="gvUchet_RowCommand" OnRowEditing="gvUchet_RowEditing" OnRowCancelingEdit="gvUchet_RowCancelingEdit"
                OnRowUpdating="gvUchet_RowUpdating" OnRowDeleting="gvUchet_RowDeleting"

                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                <%-- Theme Properties --%>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
                
                <Columns>
                    <asp:TemplateField HeaderText="Sotrudnik">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Sotrudnik") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtSotrudnik" Text='<%# Eval("Sotrudnik") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtSotrudnikFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DataPost">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("DataPost") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtDataPost" Text='<%# Eval("DataPost") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtDataPostFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NazvaniePredmeta">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("NazvaniePredmeta") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNazvaniePredmeta" Text='<%# Eval("NazvaniePredmeta") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtNazvaniePredmetaFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Kolichestvo">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Kolichestvo") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtKolichestvo" Text='<%# Eval("Kolichestvo") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtKolichestvoFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                       <asp:TemplateField HeaderText="DataVida">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("DataVida") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtDataVida" Text='<%# Eval("DataVida") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtKDataVidaFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                       <asp:TemplateField HeaderText="Adress">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Adress") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAdress" Text='<%# Eval("Adress") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtAdressFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                       <asp:TemplateField HeaderText="FIOPoluch">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("FIOPoluch") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFIOPoluch" Text='<%# Eval("FIOPoluch") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtFIOPoluchFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                       <asp:TemplateField HeaderText="Cena">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Cena") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCena" Text='<%# Eval("Cena") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtCenaFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px"/>
                            <asp:ImageButton ImageUrl="~/Images/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px"/>
                            <asp:ImageButton ImageUrl="~/Images/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px"/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ImageUrl="~/Images/addnew.png" runat="server" CommandName="AddNew" ToolTip="Add New" Width="20px" Height="20px"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="lblSuccessMessage" Text="" runat="server" ForeColor="Green" />
            <br />
            <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red" />

        </div>
    </form>
</body>
</html>
