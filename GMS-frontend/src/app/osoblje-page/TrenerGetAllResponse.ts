export interface TrenerGetAllResponse{
  treneri : TrenerGetAllResponseTrener[];
}

export interface TrenerGetAllResponseTrener {
  id: number
  ime: string
  prezime: string
  brojTelefona: string
  slika: string
}
