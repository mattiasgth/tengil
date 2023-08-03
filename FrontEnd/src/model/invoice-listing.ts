export interface TngInvoiceListing {
  id: number;
  invoiceText: string;
  dateIssued: Date | null;
  amount?: number;
  vat?: number;
  currencyName?: string;
}