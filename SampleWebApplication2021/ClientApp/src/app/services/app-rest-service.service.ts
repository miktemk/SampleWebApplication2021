import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";

import * as dto from "./dto";

@Injectable({
  providedIn: "root",
})
export class AppRestServiceService {
  constructor(
    private http: HttpClient,
    @Inject("BASE_URL")
    private baseUrl: string
  ) {}

  getEmployees(): Promise<dto.Employee[]> {
    return this.http
      .get<dto.Employee[]>(this.baseUrl + "directory/employees")
      .toPromise();
  }

  getPositions(): Promise<dto.EmployeePosition[]> {
    return this.http
      .get<dto.EmployeePosition[]>(this.baseUrl + "directory/positions")
      .toPromise();
  }

  saveEmployee(data: dto.Employee): Promise<dto.Employee[]> {
    return this.http
      .post<dto.Employee[]>(this.baseUrl + "directory/submitEmployee", data)
      .toPromise();
  }

  deleteEmployee(id: number): Promise<dto.Employee[]> {
    return this.http
      .delete<dto.Employee[]>(this.baseUrl + "directory/deleteEmployee", {
        params: { id: ''+id },
      })
      .toPromise();
  }
}
