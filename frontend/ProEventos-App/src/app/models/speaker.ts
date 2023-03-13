import { SocialMedia } from "./social-media";
import { Event } from "./event";

export interface Speaker {
  id: number;
  name: string;
  personalResume: string;
  imageURL: string;
  phone: string;
  email: string;
  socialMedia: SocialMedia[]
  speakersEvents: Event[]
  status: boolean;
}
