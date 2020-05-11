resource "google_container_cluster" "primary" {
  provider                 = google-beta
  name                     = var.name
  location                 = var.location
  initial_node_count       = var.node_count

  release_channel          {
    channel = "REGULAR"
  }

  addons_config {
    istio_config {
      disabled = var.istio_disabled
      auth     = "AUTH_MUTUAL_TLS"
    }
  }

  node_config {
    preemptible  = false
    machine_type = var.machine_type

    oauth_scopes = [
      "https://www.googleapis.com/auth/logging.write",
      "https://www.googleapis.com/auth/monitoring",
      "https://www.googleapis.com/auth/devstorage.read_only",
      "https://www.googleapis.com/auth/compute"
    ]
    }
   
}