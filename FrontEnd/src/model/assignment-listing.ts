import { Dayjs } from "dayjs";

export interface TngAssignmentListing {
  id: number;
  nameText: string;
  dateIn: Date | Dayjs | null;
  customerName: string;
}