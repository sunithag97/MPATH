import { Recommendation } from './recommendation.model';

export interface Patient {
  id: number;
  name: string;
  dateOfBirth: string;
  gender: string;
  recommendations: Recommendation[];
}