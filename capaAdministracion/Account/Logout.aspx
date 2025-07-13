<%@ Page Language="VB" AutoEventWireup="true" CodeBehind="Logout.aspx.vb" Inherits="capaAdministracion.Logout" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cerrando sesión</title>
    <style>
        body {
            display: flex;
            align-items: center;
            justify-content: center;
            height: 100vh;
            background-color: #f8f9fa;
            font-family: Arial, sans-serif;
        }
        .loader {
            border: 8px solid #f3f3f3;
            border-top: 8px solid #007bff;
            border-radius: 50%;
            width: 60px;
            height: 60px;
            animation: spin 1s linear infinite;
            margin-bottom: 20px;
        }
        @keyframes spin {
            0% { transform: rotate(0deg); }
            100% { transform: rotate(360deg); }
        }
        .message {
            text-align: center;
        }
    </style>
    <script type="text/javascript">
        setTimeout(function () {
            window.location.href = '../Default.aspx';
        }, 3000);
	</script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="message">
            <div class="loader"></div>
            <h3>Cerrando sesión...</h3>
        </div>
    </form>
</body>
</html>
