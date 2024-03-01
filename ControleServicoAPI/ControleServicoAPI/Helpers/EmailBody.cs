namespace ControleServicoAPI.Helpers
{
    public static class EmailBody
    {
        public static string EmailStringBody (string email, string emailToken)
        {
            return $@"<html>
    <head>
    </head>
    <body style=""margin:0;padding:0;font-family: Arial, Helvetica, sans-serif;"">
      <div style=""height: auto; background: linear-gradient(to top,#c9c9ff 50%, #6e6ef6 90%) no-repeat; width: 400px; padding:30px"">
        <div>
          <h1>Redefina sua senha</h1>
          <hr>
          <p>Você está recebendo esse email porque  você solicitou redefinir a senha para a conta</p>
          <p> Por favor click no botão abaixo para criar uma nova senha</p>
          
          <a href=""http://localhost:4200/reset?email={email}&code={emailToken}"""" target="" _blank"" style="" background:#0d6efd; padding:10px;border:nome;
          color:white;border-radius:4px;display:block;margin:0 auto; width:50%; text-align:center;text-decoration:none"""">Redefinir senha</a><br>
          
          <p>Atenciosamente, <br><br> Sistemas Junior</p>
        </div>
      </div>
    </div>
  </body>
</html>";
        
        }
    }
}
