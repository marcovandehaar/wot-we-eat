export interface MealOption {    
        id: string ,
        description: string ,
        mealBase: string,  
        amountOfWork: string,  
        healthy:string,
        suitableForChildren:boolean,
        vegetables: Vegetable[] | null,
  }

export interface Vegetable {
      id: string ,
      name: string ,
}
  