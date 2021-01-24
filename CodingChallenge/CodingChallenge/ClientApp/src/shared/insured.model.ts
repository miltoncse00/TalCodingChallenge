export interface InsuredInput {
  name: string;
  age: number;
  dateOfBirth: Date;
  deathSumInsured: number;
  occupation: string;
}

export interface DeathPremium {
  monthlyDeathPremium: number
}

export interface Occupations{
  occupation:string[]
}
