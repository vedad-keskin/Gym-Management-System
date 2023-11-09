
export interface FAQGetAllResponse{
  faq : FAQGetAllResponseFAQ[];

}

export interface FAQGetAllResponseFAQ {
  id: number
  pitanje: string
  odgovor: string
}
