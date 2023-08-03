import { Dayjs } from "dayjs";

export interface TngPoInListing {
  id: number;
  nameText: string;
  dateIn: Date | Dayjs | null;
  amount: number;
}