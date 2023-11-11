export interface SuplementGetAllResponse{
  suplementi : SuplementGetAllResponseSuplement[];
}
  export interface SuplementGetAllResponseSuplement {
    id: number
    naziv: string
    cijena: number
    gramaza: number
    opis: string
    slika: string
    nazivDobavljaca: string
    nazivKategorija: string
}



