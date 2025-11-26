import { defineConfig } from 'vite';
import angular from '@analogjs/vite-plugin-angular';

export default defineConfig({
  plugins: [angular()],
  server: {
    port: 4200,
    proxy: {
      '/api': {
        target: 'https://localhost:40443',
        secure: false,
        changeOrigin: true,
      }
    }
  }
});
