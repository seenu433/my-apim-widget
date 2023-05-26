export type Values = {
  externalApiUri: string
}

export const valuesDefault: Readonly<Values> = Object.freeze({
  externalApiUri: "https://myexternalapi.com",
})
