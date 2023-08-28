import { Injectable } from '@angular/core';
import { MasterService } from 'src/app/Service/master.service';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  base: string = 'Courses';
  courseType: string = 'CoursesTypes';
  courseLevel: string = 'CoursesLevels';
  sessions: string = 'Sessions'
  courseDetails: any;
  id: any;
  constructor(private master: MasterService) { }


  getCoursesTypes() {
    return this.master.getAll(this.courseType);
  }
  getCoursesLevels() {
    return this.master.getAll(this.courseLevel);
  }

  getSessions() {
    return this.master.getAll(this.sessions);
  }

  getCourse(pageSize: number, pageIndex: number, name: string, price: Number, courseTypeId: Number) {
    var courseTypeFilter = '';
    if (courseTypeId)
      courseTypeFilter = `&CourseTypeId=${courseTypeId}`;
    var priceFilter = '';
    if (price)
      priceFilter = `&Price=${price}`;

    return this.master.getAll(`${this.base}?PageSize=${pageSize}&PageIndex=${pageIndex}&Name=${name}${priceFilter}${courseTypeFilter}`);
  }
  getCoursesById(id: any) {
    return this.master.getById(this.base, id);
  }
  AddCourse(data: any) {
    return this.master.Add(this.base, data);
  }

  UpdateCourse(id: any, data: any) {
    return this.master.Update(this.base, id, data);
  }

  DeleteCourse(id: number) {
    return this.master.Delete(this.base, id);
  }
}
