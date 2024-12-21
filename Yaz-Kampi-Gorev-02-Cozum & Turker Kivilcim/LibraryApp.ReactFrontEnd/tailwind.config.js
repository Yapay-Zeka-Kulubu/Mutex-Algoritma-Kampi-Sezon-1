/** @type {import('tailwindcss').Config} */
export default {
  content: ["./src/**/*.{js,ts,jsx,tsx}",],
  theme: {
    extend: {
      colors: {
        primary: {
          light: '#374151',  // Muted dark gray
          DEFAULT: '#1F2937', // Dark gray (ideal for headers or primary buttons)
          dark: '#111827',   // Very dark gray (for heavy contrast or backgrounds)
        },
        secondary: {
          light: '#4B5563',  // Mid-gray (use for borders or light backgrounds)
          DEFAULT: '#6B7280', // Neutral gray (use for secondary text or buttons)
          dark: '#9CA3AF',   // Light gray (can be used for subtle text)
        },
        background: {
          light: '#1E293B',  // Darker background, like shelves or menus
          DEFAULT: '#111827', // Base dark background for the app
          card: '#2D3748',    // Dark card color for sections like book listings
        },
        accent: {
          DEFAULT: '#433d8b', // Soft violet (use for interactive elements like links or buttons)
          dark: '#2e236c',    // Deeper violet (for hover effects)
        },
        text: {
          light: '#D1D5DB',   // Light gray for subtle text
          DEFAULT: '#F3F4F6', // Lighter text for main content on dark backgrounds
          dark: '#E5E7EB',    // Slightly darker text for contrast
        },
        danger: {
          DEFAULT: '#EF4444', // Red for error messages or warnings
          dark: '#B91C1C',    // Dark red for more severe errors
        },
        success: {
          DEFAULT: '#508d4e', // Green for success messages
          dark: '#1a5319',    // Dark green for subtle success indicators
        },
      },
    },
  },
  plugins: [],
}