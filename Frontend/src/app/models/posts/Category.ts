export class Category {
    public getCategoryById(id: number): string {
         switch(id) {
             case(0):
                return 'General';
         }

         return null;
    }
}