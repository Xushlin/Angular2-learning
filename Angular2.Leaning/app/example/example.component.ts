import { Component,EventEmitter, Input, Output } from '@angular/core';
import { Example } from './example';

@Component({
    selector: 'example',
    templateUrl: 'app/example/example.component.html',
    styleUrls:  ['app/example/example.component.css']
})
export class ExampleComponent {
    example:Example=new Example();
    @Input()  size: number | string=1;
    @Output() sizeChange = new EventEmitter<number>();
    isSpecial :boolean=true;
    canSave:boolean=true;
    isUnchanged:boolean=true;
    toeChoice:string="Eenie";
    exapples:Example[]=[{id:22,name:"xu",title:"title1"},{id:22,name:"xu",title:"title1"},{id:22,name:"xu",title:"title1"},{id:22,name:"xu",title:"title1"},{id:22,name:"xu",title:"title1"}];

    constructor(){
        //this.example=new Example();
        this.example.id=23;
        this.example.name="This is content from ExampleComponent";
        this.example.title="Example of the binding";
    }
    setClasses() {
        let classes =  {
            saveable: this.canSave,      // true
            modified: !this.isUnchanged, // false
            special: this.isSpecial,     // true
        };
        return classes;
    }
    setStyles() {
        let styles = {
            // CSS property names
            'font-style':  this.canSave      ? 'italic' : 'normal',  // italic
            'font-weight': !this.isUnchanged ? 'bold'   : 'normal',  // normal
            'font-size':   this.isSpecial    ? '24px'   : '8px',     // 24px
        };
        return styles;
    }
    changeChoice(){
        this.toeChoice="Miney";
    }
    dec() { this.resize(-1); }
    inc() { this.resize(+1); }
    resize(delta: number) {
        this.size = Math.min(40, Math.max(8, +this.size + delta));
        this.sizeChange.emit(this.size);
    }
}

