<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Successful.aspx.cs" Inherits="doakdiabet2023.Successful" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="icerik">
        <div class="container mt-5">
            <div class="row">
                <div class="col-lg-12 text-center">
                    <h5 class="baslik d-none">Kayıt Başarılı</h5>
                    <p>
                        <asp:Image ID="ImgOk" runat="server" CssClass="w-50" Style="max-width: 180px;" ImageUrl="~/img/tick.png" />
                    </p>
                    <p class="text-center">
                        Sayın
                        <asp:Label ID="lblAdSoyad" runat="server" Text="Label"></asp:Label>
                    </p>
                    <p class="text-center">
                        Başvuru talebiniz alınmıştır.
                    </p>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
