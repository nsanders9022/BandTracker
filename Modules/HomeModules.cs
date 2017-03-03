using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;
using BandTracker.Objects;

namespace BandTracker
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => {
                return View["index.cshtml"];
            };

            Get["/bands"] = _ => {
                List<Band> allBands = Band.GetAll();
                return View["bands.cshtml", allBands];
            };

            Get["/venues"] = _ => {
                List<Venue> allVenues = Venue.GetAll();
                return View["venues.cshtml", allVenues];
            };

            Post["/bands"] = _ => {
                List<Band> allBands = Band.GetAll();
                return View["bands.cshtml", allBands];
            };

            Post["/venues"] = _ => {
                List<Venue> allVenues = Venue.GetAll();
                return View["venues.cshtml", allVenues];
            };

            Get["/band/{id}"] = parameters => {
                Band newBand = Band.Find(parameters.id);
                List<Venue> allVenues = Venue.GetAll();
                List<Venue> bandVenue = newBand.GetVenues();
                Dictionary<string, object> model = new Dictionary<string, object>();
                model.Add("band", newBand);
                model.Add("allVenues", allVenues);
                model.Add("bandVenue", bandVenue);
                return View["band.cshtml", model];
            };

            Get["/venue/{id}"] = parameters => {
                Dictionary<string, object> model = new Dictionary<string, object>();
                Venue newVenue = Venue.Find(parameters.id);
                List<Band> allBands = Band.GetAll();
                List<Band> venueBands = newVenue.GetBands();
                model.Add("venue", newVenue);
                model.Add("allBands", allBands);
                model.Add("venueBands", venueBands);
                return View["venue.cshtml", model];
            };

            Post["/bands/new"] = _ => {
                Band newBand = new Band(Request.Form["band-name"]);
                newBand.Save();
                List<Band> allBands = Band.GetAll();
                return View["bands.cshtml", allBands];
            };

            Post["/venues/new"] = _ => {
                Venue newVenue = new Venue(Request.Form["venue-name"]);
                newVenue.Save();
                List<Venue> allVenues = Venue.GetAll();
                return View["venues.cshtml", allVenues];
            };

            Get["/venue/delete/{id}"] = parameters => {
                Venue selectedVenue = Venue.Find(parameters.id);
                List<Venue> allVenues = Venue.GetAll();
                return View["venues.cshtml", allVenues];
            };

            Delete["/venue/delete/{id}"] = parameters => {
                Venue selectedVenue = Venue.Find(parameters.id);
                selectedVenue.DeleteVenue();
                List<Venue> allVenues = Venue.GetAll();
                return View["venues.cshtml", allVenues];
            };

            Get["/venue/update/{id}"] = parameters => {
                Venue selectedVenue = Venue.Find(parameters.id);
                return View["edit_venue.cshtml", selectedVenue];
            };

            Post["/venue/update/{id}"] = parameters => {
                Venue selectedVenue = Venue.Find(parameters.id);
                return View["edit_venue.cshtml", selectedVenue];
            };

            Patch["/venue/update/{id}"] = parameters => {
                Dictionary<string, object> model = new Dictionary<string, object>();
                Venue selectedVenue = Venue.Find(parameters.id);
                selectedVenue.UpdateVenue(Request.Form["new-venue-name"]);
                List<Band> allBands = Band.GetAll();
                List<Band> venueBands = selectedVenue.GetBands();
                model.Add("venue", selectedVenue);
                model.Add("allBands", allBands);
                model.Add("venueBands", venueBands);
                return View["venue.cshtml", model];
            };

            Post["/venue/add_band/{id}"] = parameters => {
                Band band = Band.Find(Request.Form["band-id"]);
                Venue venue = Venue.Find(Request.Form["venue-id"]);
                venue.AddBand(band);
                Dictionary<string, object> model = new Dictionary<string, object>();
                List<Band> allBands = Band.GetAll();
                List<Band> venueBands = venue.GetBands();
                model.Add("venue", venue);
                model.Add("band", band);
                model.Add("allBands", allBands);
                model.Add("venueBands", venueBands);
                return View["venue.cshtml",model];
            };

            Post["/band/add_venue/{id}"] = parameters => {
                Band band = Band.Find(Request.Form["band-id"]);
                Venue venue = Venue.Find(Request.Form["venue-id"]);
                band.AddVenue(venue);
                List<Venue> allVenues = Venue.GetAll();
                List<Venue> bandVenue = band.GetVenues();
                Dictionary<string, object> model = new Dictionary<string, object>();
                model.Add("band", band);
                model.Add("allVenues", allVenues);
                model.Add("bandVenue", bandVenue);
                return View["band.cshtml", model];
            };
        }
    }
}
