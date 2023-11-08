export interface ClanarinaGetAllResponse{
  clanarine : ClanarinaGetAllResponseClanarina[];

}

export interface ClanarinaGetAllResponseClanarina {
  id : number
  naziv: string
  cijena: number
  opis: string

}
