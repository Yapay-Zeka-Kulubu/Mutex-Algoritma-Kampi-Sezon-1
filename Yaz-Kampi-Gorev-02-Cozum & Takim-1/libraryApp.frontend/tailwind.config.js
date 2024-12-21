/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./index.html",
    "./src/**/*.{js,ts,jsx,tsx}",
  ],
   theme: {
     extend: {
       //to add bg image
       backgroundImage: {
         'hero-pattern': "url('loginback.jpg')",
       },
     
   },
   },
   plugins: [],
}

