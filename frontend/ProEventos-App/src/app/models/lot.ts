import { Event } from "./event";

export interface Lot {
  id: number;
  name: string;
  price: number;
  startDate?: Date;
  endDate?: Date;
  quantity: number;
  eventId: number;
  status: boolean;
}
