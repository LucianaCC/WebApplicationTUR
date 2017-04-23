<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Default"  CodeBehind="~/Index.aspx.cs"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <script runat="server">
bool IsValidEmail(string strIn)
{
    return true;  //Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"); 
}

void OnLoggingIn(object sender, System.Web.UI.WebControls.LoginCancelEventArgs e)
{
    if (!IsValidEmail(login_.UserName))
    {
        login_.InstructionText = "Enter a valid e-mail address.";
 
        e.Cancel = true;
    }
    else
    {
        login_.InstructionText = "";
    }
}

void OnLoginError(object sender, EventArgs e)
{
    login_.FailureText = "Invalid e-mail or password";
   
}
    

</script>
    <div class="login-centered" >         
    
    <asp:Login ID="login_" runat="server" onauthenticate="Authenticate"
        UserNameLabelText="User:"  OnLoggingIn="OnLoggingIn" 
        onloginerror="OnLoginError" DisplayRememberMe="False" RememberMeText="" 
        LoginButtonText="Enter" PasswordLabelText="Password:" TitleText="Log In">
    </asp:Login>
    </div>
    </form>
</body>
</html>
