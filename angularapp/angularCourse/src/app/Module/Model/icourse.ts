export interface Icourse {
    id:number;
    name:string;
    description:string;
    // courseType:string;
    price:number;
    // courseLevel:string;
    courseLevelId:number;
    courseTypeId:number;
    sessionName:string;
    durationInMins:number;
    courseLevel:IcoursesLevels;
    courseType:IcoursesTypes;
    session: ISessions[] ;
     
}

export interface IcoursesTypes {
    id:number;
    name:string;
}
export interface IcoursesLevels {
    id:number;
    name:string;
}
export interface ISessions {
    sessionName:string;
    durationInMins:number;
}
