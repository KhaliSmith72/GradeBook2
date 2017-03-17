namespace GradeBook2.Controllers {

    export class HomeController {
        public message = 'Hello from the home page!';
        
    }


    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }


    export class StudentViewController {
        public classes;
        constructor($http: ng.IHttpService) {
            $http.get('/api/user').then((results) => {
                this.classes = results.data;
                
            });
        }
    }


    


    export class AboutController {
        public message = 'Hello from the about page!';
    }
    
    export class ClassSelectionController {
        public message = 'Please select 4 classes you wish to attend';
        public classes;
        public class;
        public subject;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            $http.get('/api/user').then((results) => {
                this.classes = results.data;
                this.subject = ["Geometry", "College Lit", "Gym", "WorldHistory", "Art"];

            });
        }


        public saveClasses(subject) {
            this.$http.post('/api/user', this.class).then((results) => {
                console.log(subject);
                console.log(this.class);


                this.$state.reload();
            })
                .catch((reason) => {
                    console.log(reason);
                    console.log(subject);
        
            });
        }
    }

    export class StudentDetailsController {
        public message = 'Their fates are in your grasp';
        public classes;
        public grade;
        public user;
        public class;

        constructor(private $http: ng.IHttpService, private $stateParams:
            ng.ui.IStateParamsService, private $state: ng.ui.IStateService) {
            $http.get(`/api/instructor/${$stateParams['id']}`)
                .then((response) => {
                    this.user = response.data;
                    console.log(this.user)
            });

        }
        public editGrade(grade) {
            this.$http.post(`/api/instructor/${grade.id}`, grade)
                .then((results) => {
                    console.log(grade);
                    this.$state.reload();
                })
                .catch((reason) => {
                    console.log(reason);
                    console.log(this.class + "returning this.class");
                    console.log(grade + "returning grade");
                    
                });
        }
        public removeClass(grade) {
            this.$http.delete(`api/instructor/classes/${grade.id}`, grade)
                .then((results) => {
                    this.$state.reload();
                });
        }
        public removeUser(user) {
            this.$http.delete(`/api/instructor/${this.user.lastName}`, user)
                .then((response) => {
                    console.log(this.user.lastName);
                    console.log(user);
                    this.$state.go('instructorLogin');
                });
                }
    }



    export class InstructorLoginController {
        public message = 'Well hello there Mr. Sir';
        public classes;
        public grade;
        public user;
       
        constructor(private $http: ng.IHttpService, private $stateParams:
            ng.ui.IStateParamsService, private $state: ng.ui.IStateService) {
            $http.get('/api/instructor').then((results) => {
                this.classes = results.data;

            });

        }
        public editGrade(grade) {
            this.$http.put(`/api/instructor/${this.grade}`, this.grade)
                .then((results) => {
                    this.$state.reload();
                })
                .catch((reason) => {
                    console.log(reason);
                });
        }    
        public removeUser(user) {
            this.$http.delete(`/api/instructor/${this.user.userId}`, this.user)
                .then((response) => {
                    this.$state.go('instructorLogin');
                });
        }
        
    
    }

    export class UserController {
        public user;
        public subject;
        constructor($http: ng.IHttpService) {
            $http.get('/api/user').then((results) => {
                this.user = results.data;
                
            });
        }
    }
}
