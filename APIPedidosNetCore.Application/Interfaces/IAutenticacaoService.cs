﻿namespace APIPedidosNetCore.Application.Interfaces;

public interface IAutenticacaoService
{
    Task<string> Autenticacao(string email, string senha);
}