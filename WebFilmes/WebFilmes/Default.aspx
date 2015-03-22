<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFilmes.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblFilmes" runat="server" Text="-"></asp:Label>
            <asp:Label ID="lblAtores" runat="server" Text="-"></asp:Label>

            <asp:Button ID="btnClimaDownload" runat="server" Text="Atualizar Clima" OnClick="btnClimaDownload_Click" />

            <asp:Button ID="btnWebService" runat="server" Text="Consulta WebService" OnClick="btnWebService_Click" />

        </div>

        <div>
            <asp:GridView ID="gvwClima" runat="server" AutoGenerateColumns="False" DataMember="Data">
                <Columns>
                    <asp:BoundField DataField="Data" HeaderText="Data" />
                    <asp:TemplateField HeaderText="Previsão">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# ObterLogotipo( Eval("Icone").ToString()) %>' Height="64" Width="64" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
