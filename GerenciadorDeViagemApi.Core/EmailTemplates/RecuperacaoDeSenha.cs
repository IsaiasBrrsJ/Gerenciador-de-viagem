using GerenciadorDeViagemApi.Core.DTOs;
using GerenciadorDeViagemApi.Core.Services;

namespace GerenciadorDeViagemApi.Core.EmailTemplates
{
    public  class RecuperacaoDeSenha : IEmailTemplateServices
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
                                    <h2>Recuperação de Senha</h2>
                                    <p>Olá {emailDTO.NomeCompleto},</p>
                                    <p>Você solicitou a recuperação de senha. Clique no botão abaixo para redefinir sua senha:</p>
                                    <a target=""_blank"" href=""{""}""  class=""cta-button"">Redefinir Senha</a>
                                    <p>Se você não solicitou esta recuperação, ignore este e-mail.</p>
                                    <p>Atenciosamente,<br>Travel - ADM {DateTime.Now.ToString("dd-MM-yy HH:mm:ss")}</p>
                                </div>
                            </body>
                            </html>";


            return Task.FromResult(corpoEmail)
                       .GetAwaiter()
                       .GetResult();
           }


    }
}
