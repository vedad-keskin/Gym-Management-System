export interface NutricionstGetAllResponse{
  nutricionisti : NutricionstGetAllResponseNutricionst[];
}

export interface NutricionstGetAllResponseNutricionst {
  id: number
  ime: string
  prezime: string
  brojTelefona: string
  slika: string
}
