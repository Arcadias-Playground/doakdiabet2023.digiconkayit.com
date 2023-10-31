<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="doakdiabet2023.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpnlForm" runat="server">
        <ContentTemplate>
            <div class="row clearfix justify-content-center">
                <div class="col-md-10 mt-1">
                    <p class="text-center">
                        <strong>Kırmızı * ile işaretlenmiş tüm alanların doldurulması zorunludur.
                        </strong>
                    </p>
                    <fieldset>
                        <legend>Kişisel bilgiler</legend>
                        <table class="KuTechTable">
                            <tr>
                                <td>*</td>
                                <td>Ad Soyad</td>
                                <td>
                                    <asp:TextBox ID="txtAdSoyad" runat="server" CssClass="form-control" onchange="toUpper(this)" onkeyup="toUpper(this)"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>*</td>
                                <td>Tc Kimlik Numarası</td>
                                <td>
                                    <asp:TextBox ID="txtTCNo" runat="server" CssClass="form-control"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>*</td>
                                <td>E-Mail</td>
                                <td>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox></td>
                            </tr>

                            <tr>
                                <td>*</td>
                                <td>Telefon Numarası</td>
                                <td>
                                    <asp:TextBox ID="txtTelefon" runat="server" CssClass="form-control"></asp:TextBox></td>
                            </tr>

                            <tr>
                                <td>*</td>
                                <td>Sicil Numarası</td>
                                <td>
                                    <asp:TextBox ID="txtSicilNo" runat="server" CssClass="form-control"></asp:TextBox></td>
                            </tr>

                            <tr>
                                <td>*</td>
                                <td>Branş</td>
                                <td>
                                    <asp:TextBox ID="txtBranş" runat="server" CssClass="form-control"></asp:TextBox></td>
                            </tr>

                            <tr>
                                <td>*</td>
                                <td>Meslek</td>
                                <td>
                                    <asp:TextBox ID="txtMeslek" runat="server" CssClass="form-control"></asp:TextBox></td>
                            </tr>

                            <tr>
                                <td>*</td>
                                <td>Ünvan</td>
                                <td>
                                    <asp:DropDownList ID="ddlUnvan" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="Asistan" Value="Asistan" />
                                    </asp:DropDownList>
                            </tr>

                            <tr>
                                <td>*</td>
                                <td>Hastane</td>
                                <td>
                                    <asp:TextBox ID="txtHastane" runat="server" CssClass="form-control" onchange="toUpper(this)" onkeyup="toUpper(this)"></asp:TextBox></td>
                            </tr>

                            <tr>
                                <td>*</td>
                                <td>Şehir</td>
                                <td>
                                    <asp:TextBox ID="txtSehir" runat="server" CssClass="form-control" onchange="toUpper(this)" onkeyup="toUpper(this)"></asp:TextBox></td>
                            </tr>

                            <tr>
                                <td>*</td>
                                <td>İlçe</td>
                                <td>
                                    <asp:TextBox ID="txtIlce" runat="server" CssClass="form-control" onchange="toUpper(this)" onkeyup="toUpper(this)"></asp:TextBox></td>
                            </tr>

                            <tr>
                                <td>*</td>
                                <td>Doğum Tarihi</td>
                                <td>
                                    <asp:TextBox ID="txtDogumTarihi" runat="server" CssClass="form-control" onchange="toUpper(this)" onkeyup="toUpper(this)"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td class="bg-transparent"></td>
                                <td>
                                    <asp:CheckBox ID="chkKVKKOnay" runat="server" />
                                    <a id="lnkKVKKMetni" runat="server" target="_blank" href="files/Kvkk.pdf">KVKK Onayı Veriyorum</a>
                                </td>
                            </tr>




                        </table>
                    </fieldset>
                    <div class="d-flex justify-content-center align-items-center">
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-block btn-success mt-3 mb-3" OnClick="lnkbtnKayitOl_Click" OnClientClick="$(this).css('display', 'none');"><i class="fa fa-plus"></i>&nbsp;Başvuruyu Tamamla</asp:LinkButton>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- <asp:SqlDataSource runat="server" ID="KatilimcListesi" ConnectionString='<%$ ConnectionStrings:doakdiabet2023 %>' ProviderName='<%$ ConnectionStrings:doakdiabet2023.ProviderName %>' SelectCommand="SELECT * FROM [KatilimciTablosu]"></asp:SqlDataSource>--%>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
