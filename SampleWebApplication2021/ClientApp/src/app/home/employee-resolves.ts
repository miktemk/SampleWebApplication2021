import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { Observable } from "rxjs";

import * as dto from "app/services/dto";
import { AppRestServiceService } from "app/services/app-rest-service.service";

@Injectable({ providedIn: 'root' })
export class EmployeeResolver implements Resolve<dto.Employee[]> {
  constructor(private service: AppRestServiceService) {}

  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Promise<dto.Employee[]> {
    return this.service.getEmployees();
  }
}

@Injectable({ providedIn: 'root' })
export class PositionsResolver implements Resolve<dto.EmployeePosition[]> {
  constructor(private service: AppRestServiceService) {}

  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Promise<dto.EmployeePosition[]> {
    return this.service.getPositions();
  }
}

export type EmployeeResolveKeys = {
  employees: dto.Employee[];
  positions: dto.EmployeePosition[];
};