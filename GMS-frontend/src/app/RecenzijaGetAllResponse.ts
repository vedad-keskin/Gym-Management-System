export interface RecenzijaGetAllResponse{
  recenzije : RecenzijaGetAllResponseRecenzija[];
}

export interface RecenzijaGetAllResponseRecenzija {
  id: number
  ime: string
  prezime: string
  zanimanje: string
  tekst: string
  slika: string
}
