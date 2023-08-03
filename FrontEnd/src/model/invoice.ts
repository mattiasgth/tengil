import { Dayjs } from "dayjs";

export interface TngInvoice {
  id: number;
  invoiceText: string;
  customerId?: number;
  dateIssued: Date | Dayjs | null;
  datePaid: Date | Dayjs | null;
  amount?: number;
  vat?: number;
  currencyName?: string;
  createdById?: number;
  dateDue?: Date | Dayjs | null;
  rate: number;
  templateId?: number;
  discount: number;
  rounding: number;
  recipient?: string;
  address1?: string;
  address2?: string;
  postalCode?: string;
  city?: string;
  country?: string;
  vatcode?: string;
  refOurs?: string;
  refYours?: string;
}