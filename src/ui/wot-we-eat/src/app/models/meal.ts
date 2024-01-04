import { MealOption, MeatFish } from "./meal-option.model";

export interface Meal {
    id: string;
    mealOption: MealOption|null;  // assuming you want to store the entire meal option object
    date: Date;
    selectedMeatFishes: MeatFish[]|null;
  }