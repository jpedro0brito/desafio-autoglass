﻿using System;

namespace Domain.ValueObjects
{
    public class Cnpj
    {
		public const int ValorMaxCnpj = 14;
		public const int ValorMaxCnpjComMascara = 18;
		protected Cnpj() { }
		public Cnpj(string cnpj)
		{
			Codigo = cnpj;
		}

		public string Codigo { get; private set; }

		public string ComFormatacao()
		{
			if (Codigo.Length == ValorMaxCnpjComMascara) return Codigo;

			return Convert
				.ToUInt64(Codigo)
				.ToString(@"00\.000\.000\/0000\-00");
		}

		public string SemFormatacao()
		{
			if (Codigo.Length == ValorMaxCnpj) return Codigo;

			return Codigo
				.Replace(".", string.Empty)
				.Replace("/", string.Empty)
				.Replace("-", string.Empty);
		}
	}
}
