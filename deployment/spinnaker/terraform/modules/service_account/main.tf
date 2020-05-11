resource "google_service_account" "default" {
  account_id   = var.name
  display_name = var.name
}

resource "google_service_account_key" "default" {
  service_account_id = google_service_account.default.name
}
