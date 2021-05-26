import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { AppRestServiceService } from "app/services/app-rest-service.service";
import * as dto from "app/services/dto";

import { EmployeeResolveKeys } from "./employee-resolves";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.less"]
})
export class HomeComponent {
  employees: dto.Employee[];
  positions: dto.EmployeePosition[];
  activeEmployee: dto.Employee;

  constructor(
    private restService: AppRestServiceService,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit() {
    const resolveData = this.activatedRoute.snapshot.data as EmployeeResolveKeys;
    this.employees = resolveData.employees;
    this.positions = resolveData.positions;
  }

  onEmployeeSelected(employee: dto.Employee) {
    this.activeEmployee = employee;
  }

  onNewEmployee() {
    this.activeEmployee = {
      fullName: "",
      address: "",
      phoneNumber: "",
      positionID: null,
    } as dto.Employee;
  }

  onSavePressed(employeeForm: dto.Employee) {
    const toSubmit = {
      id: this.activeEmployee.id || null,
      fullName: employeeForm.fullName,
      address: employeeForm.address,
      phoneNumber: employeeForm.phoneNumber,
      positionID: parseInt(''+employeeForm.positionID),
    } as dto.Employee;
    this.restService.saveEmployee(toSubmit).then(data => {
      this.activeEmployee = null;
      this.employees = data;
    });
  }

  deleteEmployee(id: number) {
    this.restService.deleteEmployee(id).then(data => {
      if (this.activeEmployee && this.activeEmployee.id === id)
        this.activeEmployee = null;
      this.employees = data;
    });
  }
}
