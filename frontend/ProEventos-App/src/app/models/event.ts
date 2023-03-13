import { Lot } from "./lot";
import { SocialMedia } from "./social-media";
import { Speaker } from "./speaker";

export interface Event {
  id: number;
  city: string;
  date?: string;
  theme: string;
  amountPeople: number;
  imageURL: string;
  phone: string;
  email: string;
  lots: Lot[];
  socialMedia: SocialMedia[];
  speakersEvents: Speaker[];
  status: boolean;
}
