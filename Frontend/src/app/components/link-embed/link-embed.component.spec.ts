import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LinkEmbedComponent } from './link-embed.component';

describe('LinkEmbedComponent', () => {
  let component: LinkEmbedComponent;
  let fixture: ComponentFixture<LinkEmbedComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LinkEmbedComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LinkEmbedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
