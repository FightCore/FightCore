import { ErrorHandler, Inject, Injector, Injectable } from "@angular/core";

@Injectable()
export class AppErrorHandler extends ErrorHandler {

  constructor(@Inject(Injector) private injector: Injector) {
    super();
  }

  public handleError(error: any): void {
    super.handleError(error);
  }
}
