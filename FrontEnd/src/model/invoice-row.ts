export interface TngInvoiceRow {
  id: number;
  choreId: number | null;
  rowText: string;
  unitId: number | null;
  extent: number;
  pricePerUnit: number;
  vat: number;
  discount: number;
  templateId: number | null;
  invoiceId: number | null;
}