using GerenciadorDeViagemApi.Core.DTOs;
using GerenciadorDeViagemApi.Core.Services;

namespace GerenciadorDeViagemApi.Core.EmailTemplates
{
    public class PrimeiroAcesso : IEmailTemplateServices
    {
        public async Task<string> GenerateTemplate(EmailDTO emailDTO)
        {
            string corpoEmail = $@"<!DOCTYPE html>
                            <html lang=""pt-br"">
                            <head>
                                <meta charset=""UTF-8"">
                                <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                                <title>Recuperação de Senha</title>
                                <style>
                                    body {{
                                        font-family: 'Arial', sans-serif;
                                        background-color: #f4f4f4;
                                        margin: 0;
                                        padding: 0;
                                    }}
                            
                                    .container {{
                                        max-width: 600px;
                                        margin: 20px auto;
                                        background-color: #fff;
                                        padding: 20px;
                                        border-radius: 5px;
                                        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                                    }}
                            
                                    h2 {{
                                        color: #333;
                                    }}
                            
                                    p {{
                                        color: #555;
                                    }}
                            
                                    .cta-button {{
                                        display: inline-block;
                                        padding: 10px 20px;
                                        background-color: #1179e9d2;
                                        color: rgb(255, 255, 255);
                                        text-decoration: none;
                                 
                                        border-radius: 5rem;
                                    }}

                                          a{{position: relative;
                                    }}
                                    .cta-button strong::after{{
                                     content: '';
                                     position: absolute;
                                     width: 0;
                                     right: 25%;
                                     background-color: #0A1128;
                                     font-weight: bolder;
                                     height: 0.2rem;
                                     top: 2rem;
                                     transition: all 300ms ease-in-out;

                                    }}

                                    .cta-button:hover strong::after{{
                                        width: 50%;
                                        left:25%;
                                    }}
                                </style>
                            </head>
                            <body>
                               <div class=""container"">
                                    <h2>Primeiro Acesso</h2>
                                    <p>Olá {emailDTO.NomeCompleto}, segue suas credenciais para primeiro acesso</p>
                                    <fieldset>
                                        <legend>Credenciais</legend>
                                        <p>Login:  {emailDTO.Matricula},</p>
                                        <p>Senha:  {emailDTO.Senha},</p>
                                    </fieldset>
                                   
                                    <p>Clique no botão abaixo para ser redirecionado para realizar o login:</p>
                                    <a  target=""_blank"" href=""#"" class=""cta-button""><strong><em>Primeiro acesso</em></strong></a>
                                    <p>Se você não realizou a criação de conta na <strong>Travel E-Corp</strong>, <mark><em>ignore</em> </mark>este e-mail.</p>
                                    <hr>
                                    <br>
                                    <br>
                                    <p>Atenciosamente,<br>&copy; Travel - ADM  {DateTime.Now.ToString("dd-MM-yy HH:mm:ss")}</p>
                                </div>
                            </body>
                            </html>";

            return Task.FromResult(corpoEmail)
                    .GetAwaiter()
                    .GetResult();
        }
    }
}
